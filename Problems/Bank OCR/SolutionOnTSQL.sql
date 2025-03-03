DECLARE @digitsTemplate VARCHAR(1000) = '
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|';


DECLARE @digits11 VARCHAR(1000) = '
 _     _  _  _ 
| |  | _|  ||_|
|_|  ||_   | _|';

DECLARE @digits12 VARCHAR(1000) = '
 _  _  _ 
|_| _|| |
|_||_ |_|';

DECLARE @digits13 VARCHAR(1000) = '
 _  _  _  _  _     _  _     _ 
|_||_|  ||_ |_ |_| _| _|  || |
 _||_|  ||_| _|  | _||_   ||_|';

DECLARE @digits1 VARCHAR(1000) = '
 _  _  _  _  _  _     _  _     _  _ 
| ||_||_|  ||_ |_ |_| _| _|  || || |
|_| _||_|  ||_| _|  | _||_   ||_||_|';

DECLARE @input VARCHAR(5000) = @digitsTemplate + @digits1;
WITH Numbers AS (
      SELECT Iter = 1
      UNION ALL
      SELECT Iter + 1 FROM Numbers WHERE Iter < LEN(@input)
),
Digits AS (
      SELECT 
        Code =  WithCode.Code,
        Digit = STRING_AGG(WithCode.Char, '') WITHIN GROUP (ORDER BY Id)
      FROM (
              SELECT 
                  WithId.Id, 
                  WithId.Char, 
                  Code = CASE 
                            WHEN WithId.Id < 90 THEN (WithId.Id % 30) / 3
                            ELSE 10 + ((WithId.Id - 90) % ((LEN(@digits1) - 6) / 3)) / 3
                         END 
              FROM (
                        SELECT 
                            Id = ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1, 
                            Char = SplitedByChars.Char
                        FROM (
                                SELECT
                                    Iter = N.Iter,
                                    Char = SUBSTRING(@input, N.Iter, 1)
                                FROM Numbers AS N
                            ) AS SplitedByChars
                        WHERE SplitedByChars.Char IN (' ', '_', '|')
                	) AS WithId
            ) AS WithCode
      GROUP BY WithCode.Code
)
SELECT CAST(STRING_AGG(A.Code, '') AS BIGINT) 
FROM (
        SELECT 
          TemplateDigits.Code,
          NumberDigits.Digit
        FROM (
            SELECT *
            FROM Digits AS D
            WHERE D.Code > 9
        ) AS NumberDigits
        LEFT JOIN (
            SELECT *
            FROM Digits AS D
            WHERE D.Code < 10
        ) AS TemplateDigits
        ON NumberDigits.Digit = TemplateDigits.Digit
    ) AS A
OPTION (MAXRECURSION 1000)
