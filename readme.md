.Net version  = .Net 6

There are two hosting projects used to develop this requirement,
1. IdentityServer - This is using for the authentication, authentication and user managment - https://identityserver4.readthedocs.io/en/latest/index.html
  - Debug url:- http://localhost:5001/
2. NetGroupInventory.Service - This is using for the manage inventory system related transactions
  - Debug url:- https://localhost:44321/

*Important -Both services above should be up and run to run the Angular project

Databases are hosted in the Azure cloud and Ef core is used as a database communication technology

Admin password
 - user name :- admin@test.com
 - password: :- 1qaz!QAZ

Technologies :- .Net 6, MediateR, Ef core, RestEase, IdenityServer4

Architecture :- Clean architecture

Patterns: - CQRS, Repository, Unit of work   
 
