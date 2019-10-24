select Name,SelledOutLastMonth,SellingCount,ROUND(Price,2),(SelledOutLastMonth/(SellingCount + SelledOutLastMonth)) * 100 from Communitys 
where UnitId = 1
ORDER by (SelledOutLastMonth/(SellingCount + SelledOutLastMonth)) desc  ,Price asc 
