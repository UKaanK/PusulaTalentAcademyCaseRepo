![pusulaacademy](https://github.com/user-attachments/assets/6b038fce-93c5-4f4e-b08f-f43c4b66a19d)
c# form uygulamasında görünümü

![sql](https://github.com/user-attachments/assets/ac737702-75e1-49d4-bc0b-a18833f9d6ff)
SQL Sorguları

//Her Ürün İçin Yıllık Toplam Satış Miktarını ve Satış Sayısını Hesaplama
SELECT
    p.ProductName AS ÜrünAdı,
    YEAR(s.SaleDate) AS SatışYılı,
    SUM(s.Quantity) AS ToplamSatışMiktarı,
    SUM(s.Quantity * p.Price) AS ToplamSatışTutarı
FROM
    Sales s
    JOIN Products p ON s.ProductID = p.ProductID
GROUP BY
    p.ProductName,
    YEAR(s.SaleDate)
ORDER BY
    p.ProductName,
    SatışYılı;




//En Yüksek Toplam Satış Miktarına Sahip Ürünü Belirleme
SELECT TOP 1
    p.ProductName AS ÜrünAdı,
    SUM(s.Quantity * p.Price) AS ToplamSatışTutarı
FROM
    Sales s
    JOIN Products p ON s.ProductID = p.ProductID
GROUP BY
    p.ProductName
ORDER BY
    ToplamSatışTutarı DESC;

