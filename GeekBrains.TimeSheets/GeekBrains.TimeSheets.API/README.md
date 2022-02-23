# GeekBrains.TimeSheets.API
Микросервис реализует возможность взаимодействия по типу CRUD с двумя контроллерами: Users и Employees. Для использования сервиса необходимо произвести авторизацию через логин и пароль ранее созданного пользователя (метод create открыт для возможности регистрации пользователей в Users).

## Описание Users-API
/Users/add - добавление пользователя в соответствии с телом запроса

/Users/get/{id} - запрос пользователя по id

/Users/update - обновление пользователя в соответствии с телом запроса

/Users/get/{id} - удаление пользователя по id

### USER-DTO
```
[Формат валидации: "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"]
Guid Id
[Формат валидации: не более 20 символов]
string Username
[Формат валидации: не более 50 символов]
string PasswordHash
string Salt
[Формат валидации: не более 20 символов]
string Role
string RefreshToken
```

## Описание Employees-API
/Employees/add - добавление сотрудника в соответствии с телом запроса

/Employees/get/{id} - запрос сотрудника по id

/Employees/update - обновление сотрудника в соответствии с телом запроса

/Employees/get/{id} - удаление сотрудника по id

### EMPLOYEE-DTO
```
[Формат валидации: "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"]
Guid Id
[Формат валидации: "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"]
Guid UserId
bool IsDeleted
```

## Описание Authenticate-API
/api/Authenticate/gettoken?login={login}&password={password} - получение пары токенов по логину и паролю

/api/Authenticate/refresh - обновление пары токенов по токену обновления (из файлов cookie)