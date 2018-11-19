DECLARE @Letters TABLE(letter VARCHAR(5))

INSERT INTO @Letters VALUES ('H'),('e'),('l'),('o')


SELECT
	L1.letter + L2.letter + L3.letter + L4.letter + L5.letter AS 'Message'
FROM
	@Letters L1
	CROSS JOIN
	@Letters L2
	CROSS JOIN
	@Letters L3
	CROSS JOIN
	@Letters L4
	CROSS JOIN
	@Letters L5
WHERE
	L1.letter = 'H'
	AND
	L2.letter = 'e'
	AND
	L3.letter = 'l'
	AND
	L4.letter = 'l'
	AND
	L5.letter = 'o';