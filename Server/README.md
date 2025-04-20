# Endpoints
The backend exposes the standard CRUD style HTTP endpoints.

You can view, and try, these via Swagger UI when running the Server in Development mode
1. From the project root run `docker compose up --build`

   _- NOTE: We don't specify the docker-compose file so we use the override file for development mode_
2. Go to: http://localhost:8080/swagger

## POST /api/Task
### Request Body
```json
{
  "title": "string",
  "description": "string",
  "status": "Pending",
  "dueDate": "2025-04-19T16:45:56.121Z"
}
```
### Response Body
```json
{
  "id": 1,
  "title": "string",
  "description": "string",
  "status": "Pending",
  "dueDate": "2025-04-19T16:45:56.121Z"
}
```
## GET /api/Task
### Response Body
```json
[
   {
      "id": 1,
      "title": "string",
      "description": "string",
      "status": "Pending",
      "dueDate": "2025-04-19T16:45:56.121Z"
   },
   {
      "id": 2,
      "title": "another string",
      "description": "another string",
      "status": "Completed",
      "dueDate": "2025-04-21T16:45:56.121Z"
   }
]
```
## GET /api/Task/{id}
### Response Body
```json
{
  "id": 1,
  "title": "string",
  "description": "string",
  "status": "Pending",
  "dueDate": "2025-04-19T16:45:56.121Z"
}
```
## PUT /api/Task/{id}
### Request Body
```json
{
  "title": "updated string",
  "description": "updated string",
  "status": "InProgress",
  "dueDate": "2025-04-21T16:45:56.121Z"
}
```
### Response Body
```json
{
  "id": 1,
  "title": "updated string",
  "description": "updated string",
  "status": "InProgress",
  "dueDate": "2025-04-21T16:45:56.121Z"
}
```
## DELETE /api/Task/{id}
### Response Body
```json
{
   "id": 1,
   "title": "string",
   "description": "string",
   "status": "Pending",
   "dueDate": "2025-04-19T16:45:56.121Z"
}
```
