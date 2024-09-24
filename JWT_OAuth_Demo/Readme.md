```
curl --location 'http://localhost:5077/api/auth/login' \
--header 'Content-Type: application/json' \
--data '{
  "username": "user",
  "password": "password"
}'
```
```
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiZDA3ZDM2OTItY2QwZi00YWNlLWE3NzEtOTk4ZGQyMTgwMWQ0IiwiZXhwIjoxNzI3MTU0NDE1LCJpc3MiOiJodHRwczovL3lvdXJhcHAuY29tIiwiYXVkIjoiaHR0cHM6Ly95b3VyYXBwLmNvbSJ9.U-8zl0NDtDAWpP2TR6CtfmT0ia42tJuntHT5KYCZGUo"
}
```

```
curl --location --request GET 'http://localhost:5077/api/secure' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiYmI1ZDRhNjUtZWFhNy00MDdmLWI0Y2MtYWUyZjlmNmRhNGFhIiwiZXhwIjoxNzI3MTU0MTI5LCJpc3MiOiJodHRwczovL3lvdXJhcHAuY29tIiwiYXVkIjoiaHR0cHM6Ly95b3VyYXBwLmNvbSJ9.P2nrU9TvkcgixVl53DlLJ5GQpHCEQN3tezL0QIYUXKg' \
--data '{
  "username": "user",
  "password": "password"
}'
```

```
{
    "secret": "This is protected data"
}
```
