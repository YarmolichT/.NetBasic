INSERT INTO dbo.Product 
VALUES 
('Milk', 'White liquid', 1, 10, 5, 5),
('Water', 'Transparent liquid', 1, 10, 5, 5),
('CocaCola', 'Blank liquid', 1, 10, 5, 5),
('Sprite', 'Transparent liquid', 1, 10, 5, 5),
('FanFan', 'Orange liquid', 1, 10, 5, 5),
('Cheese', 'Orange', 1, 10, 5, 5),
('Sweets', 'Dark chocolate', 1, 10, 5, 5)

 

INSERT INTO dbo.Orders
VALUES 
(0, GETUTCDATE(), GETUTCDATE(), 1),
(1, GETUTCDATE(), GETUTCDATE(), 2),
(2, GETUTCDATE(), GETUTCDATE(), 3),
(3, GETUTCDATE(), GETUTCDATE(), 4),
(4, GETUTCDATE(), GETUTCDATE(), 5),
(5, GETUTCDATE(), GETUTCDATE(), 6),
(6, GETUTCDATE(), GETUTCDATE(), 7)  