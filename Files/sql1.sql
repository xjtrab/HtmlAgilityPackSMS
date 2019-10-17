select Name,SelledOutLastMonth,SellingCount,ROUND(Price,2),(SelledOutLastMonth/(SellingCount + SelledOutLastMonth)) * 100 from Communitys 
ORDER by (SelledOutLastMonth/(SellingCount + SelledOutLastMonth)) desc  ,Price asc 
