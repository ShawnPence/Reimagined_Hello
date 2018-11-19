CREATE TABLE #Letters (position INT, letter VARCHAR(1))
INSERT INTO #Letters (position, letter)
	VALUES (1,'H'),(2,'e'),(3,'l'),(4,'l'),(5,'o'),(6,' ')
	       ,(7,'W'),(8,'o'),(9,'r'),(10,'l'),(11,'d'),(12,'!')

SELECT 
	REPLACE((SELECT
		',' + letter 
	FROM
		#Letters
	ORDER BY 
		position
	FOR
		XML PATH ('')
	),',','') as 'Message'

DROP TABLE #Letters;
