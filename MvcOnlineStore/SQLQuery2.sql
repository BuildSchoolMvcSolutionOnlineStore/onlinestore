--FindTopAmountByCustomerId  ����O���B�̦h���Ȥ�
SELECT Top 3
c.CustomerName,SUM(p.UnitPrice*od.Quantity-od.Discount) AS Total
FROM Customers c
INNER JOIN Orders o ON c.CustomerID=o.CustomerID
INNER JOIN OrderDetails od on o.OrderID=od.OrderID
INNER JOIN Products p ON od.ProductID=p.ProductID
GROUP BY c.CustomerName
ORDER By Total DESC


--SignInCustomer  �Ȥ�n�J(��X�ŦX��ID�ä��K�X�O�_���T)
