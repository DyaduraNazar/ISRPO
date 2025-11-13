CREATE TABLE products (
	id INT PRIMARY KEY,
	name NVARCHAR(100),
	price DECIMAL(18, 2)
);

INSERT INTO products (id, name, price) VALUES (1, 'Яблоко', 20.00);
INSERT INTO products (id, name, price) VALUES (2, 'Банан', 15.00);
INSERT INTO products (id, name, price) VALUES (3, 'Молоко', 30.00);

