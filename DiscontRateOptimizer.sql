BEGIN TRANSACTION;
/* Create a table called SPECIALOFFERS */
CREATE TABLE SPECIALOFFERS(Id integer PRIMARY KEY, RoomPrice decimal, DiscountRate decimal, Category int);
/* Create few records in this table */
INSERT INTO SPECIALOFFERS VALUES(1, 1000, 2, 1);
INSERT INTO SPECIALOFFERS VALUES(2, 2000, 2, 2);
INSERT INTO SPECIALOFFERS VALUES(3, 1500, 3, 1);
INSERT INTO SPECIALOFFERS VALUES(4, 750, 5, 2);
INSERT INTO SPECIALOFFERS VALUES(5, 1000, 10, 5);
COMMIT;

-- Select category by the max discount rate. 
SELECT Category, SUM(DiscountRate*(RoomPrice/100)) AS DiscountRate FROM SPECIALOFFERS GROUP BY Category ORDER BY  DiscountRate DESC;

SELECT * FROM SPECIALOFFERS WHERE Category = (SELECT Category FROM (SELECT Category, MAX(DiscountRate) FROM (SELECT Category, SUM(DiscountRate) AS DiscountRate FROM SPECIALOFFERS GROUP BY Category ORDER BY  DiscountRate DESC)));