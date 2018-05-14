--FindTopAmountByCustomerId  找消費金額最多的客戶
SELECT Top 3
c.CustomerName,SUM(p.UnitPrice*od.Quantity-od.Discount) AS Total
FROM Customers c
INNER JOIN Orders o ON c.CustomerID=o.CustomerID
INNER JOIN OrderDetails od on o.OrderID=od.OrderID
INNER JOIN Products p ON od.ProductID=p.ProductID
GROUP BY c.CustomerName
ORDER By Total DESC


--SignInCustomer  客戶登入(找出符合的ID並比對密碼是否正確)
