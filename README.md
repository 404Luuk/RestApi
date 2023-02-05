# Ticket Rest API <br/>

#### A Rest API to submit, get, edit and delete tickets

This project was made to practice with .NET6 & RestAPI backend.

### How to run

After cloning run "dotnet build" inside folder to get build files.
Then run "dotnet run --project <./FOLDERNAME>"

<br/><br/>
# SupportTicket RestAPI
An overview of the request & response objects

## Create ticket

### Request
```js
POST /tickets
```

```json
{
	"username": "John Doe",
	"email": "John12@gmail.com",
	"description": "Failure on build",
	"tags": [
		".NET6",
		"Build",
		"package"
	]
	
}
```
Note: A submitDate & editDate field will also be added on create & edit

### Reponse
```js
201 Created
```

```yml
Location: {{host}}/Tickets/{{id}}
```

```json
{
    	"id": "00000000-0000-0000-0000-000000000000",
	"email": "John12@gmail.com",
	"description": "Failure on build",
	"submitDate": "2022-01-01T00:00:00",
	"editDate": "2022-01-01T00:00:00",
	"tags": [
		".NET6",
		"Build",
		"package"
	]
	
}
```
