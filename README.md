# BookStore
Book Store Demo

**Swagger**
```
swagger/index.html
```
In Postman -> add header content-type application/json
Body should be Raw with json data

**Get** To get all records
```
https://localhost:44302/api/books/
```

To get single record
```
https://localhost:44302/api/books/1
```

**Post** To insert record
```
https://localhost:44302/api/books/
{
    "title" : "nirmal1",
    "description" : "Niraml2",
    "author" : "nirmal Author2",
    "price" : 10.20
}
```
**Put** To update record
```
https://localhost:44302/api/books/1
{
    "id":1
    "title" : "nirmal1",
    "description" : "Niraml2",
    "author" : "nirmal Author2",
    "price" : 10.20
}
```

**Delete** To delete single record

```
https://localhost:44302/api/books/1
```
