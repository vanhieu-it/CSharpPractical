### Minaimal API
- `` cd MinimalAPI/MinimalAPI ``
- `` dotnet run ``

### cURL API

- GET tất cả:
```
GET http://localhost:5000/todos
```
- POST thêm mới:
```
POST http://localhost:5000/todos
Body: { "title": "Learn Minimal API", "isComplete": false }
```
- GET theo ID:
```
GET http://localhost:5000/todos/1
```
- PUT cập nhật:
```
PUT http://localhost:5000/todos/1
Body: { "title": "Learn Minimal API - Updated", "isComplete": true }
```
- DELETE xóa theo ID:
```
DELETE http://localhost:5000/todos/1
```
