It is a financial instrument trading system that has two types of users - customers and employees.
Unauthorized users can only access "Real Time Trade" and "Financial Instruments"
"Real Time Trade" presents in tabular form the latest trade for each issue, with an active detail button for each financial instrument, and "Submit An Order" is only active for clients.
"Financial Instruments" - presents in tabular form, with options for filtering and sorting, all financial instruments that are active for trading, again with a details button.
After registering a new user, he must choose whether to register as a customer or as an employee
Customers
There are two options for a customer - an individual or a corporative, and a registration form must be filled out. Forms have edit and delete option.
Once completed and submitted, the registration form has a status of "NotChecking" and an employee is expected to "Accepted" or "Rejected" it. Upon Accepted, the respective customer's account ("Client" entity at Data.Models) is created and he can deposit money and trade. Upon rejection, the user cannot become a customer.
Approval customers, in addition to the two listed, have the following additional options:
"For me" Details about it;
"My trade" provides tabular information about his trades with options for filtering and sorting.
"My acount" Visualizes cash balances and enables the account to be funded.
"My orders" provides tabular information about orders submitted by the client with options for filtering and sorting.
"New order" form for placing an order. Validations are set, such as when placing a buy order, whether there are enough available funds for all open buy orders. When selling an order - whether he has the necessary financial instruments for sale. Upon successful submission of an order, a check is made for matching with an open order and, if there is one, a deal is concluded.

Employees
After completing an employee form, it must be approved by an Administrator to activate the employee's rights.
it has the following additional forms:
"All Clients` Data" in tabular form, with filtering options, visualizes data from submitted client forms, with a link to details where unverified forms can be accepted or rejected.
"For me" Employee details with option to delete and edit.
"Check orders" All submitted orders are visualized in tabular form with the option of filtering and sorting, and if the order is active, it can be deleted.
"Check traders" The completed transactions are visualized in tabular form.
"Funded client account" Enables the client to add financial instruments.
An employee with the Administrator role
In addition to the employee functions, the Role has an "All Employees" form that visualizes all employees in a tabular form with filtering options with a details button and the ability to edit the employee's data, including status.
