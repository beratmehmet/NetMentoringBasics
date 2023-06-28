INSERT INTO Person (FirstName, LastName)
VALUES ('John', 'Doe'), 
       ('Jane', 'Doe'), 
       ('Bob', 'Smith');

INSERT INTO Address (Street, City, State, ZipCode)
VALUES ('123 Main St', 'New York', 'NY', '10001'), 
       ('456 Oak Ave', 'Los Angeles', 'CA', '90001'), 
       ('789 Elm St', 'Chicago', 'IL', '60601');

INSERT INTO Company (Name, AddressId)
VALUES ('ABC Inc', 2), 
       ('XYZ Corp', 3), 
       ('123 LLC', 4);

INSERT INTO Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
VALUES (2, 2, 'ABC Inc', 'Manager', 'John Doe'), 
       (3, 3, 'XYZ Corp', 'Developer', 'Jane Doe'), 
       (4, 4, '123 LLC', 'Sales', 'Bob Smith');