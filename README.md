# fitness

- Скачать Docker 

- В командной строке

- Перейти в папку ./backend/fitness

- Выполнить команду docker-compose up -d

# Подробно:

### Скачай Docker (Это для адекватной сборки проекта в контейнер, чтобы не делать себе мозги).

### Клонируй себе файлы с гитхаб. (Смотри, чтобы папка не была в "Мои документы")

### Зайди в консоль и выполни cd <путь к файлу> туда, где будет лежать файл Dockerfile

```
D:\>cd D:\Вова Важное\GitHub\fitness\backend\Fitness
```

### Запусти сам докер (само собой разумеется)

### Выполни команду docker-compose up -d

```
docker-compose up -d
```

```
D:\Вова Важное\GitHub\fitness\backend\Fitness>docker-compose up -d
```

### Проверь работу с помощью docker ps

```
docker ps
```

```
D:\Вова Важное\GitHub\fitness\backend\Fitness>docker ps
CONTAINER ID   IMAGE                 COMMAND                  CREATED              STATUS                        PORTS                                         NAMES
4d5238aced34   fitness-fitness-api   "dotnet Fitness.API.…"   About a minute ago   Up About a minute             0.0.0.0:5000->8080/tcp, [::]:5000->8080/tcp   fitness-api
0ff77d95cd89   postgres:17-alpine    "docker-entrypoint.s…"   About a minute ago   Up About a minute (healthy)   0.0.0.0:5432->5432/tcp, [::]:5432->5432/tcp   postgres
```

## Проверка работы на пост и гет запрос

### Post

```
curl -X POST http://localhost:5000/Memberships -H "Content-Type: application/json" -d "{\"name\":\"Премиум\",\"descriptions\":\"Безлимитный доступ во все зоны, включая бассейн и спа\",\"price\":5000}"
```

```
D:\Вова Важное\GitHub\fitness\backend\Fitness>curl -X POST http://localhost:5000/Memberships -H "Content-Type: application/json" -d "{\"name\":\"Премиум\",\"descriptions\":\"Безлимитный доступ во все зоны, включая бассейн и спа\",\"price\":5000}"
"5326b2b9-a65b-4360-a4d9-496284eb5a52"
```

### Get

```
curl http://localhost:5000/Memberships
```

```
D:\Вова Важное\GitHub\fitness\backend\Fitness>curl http://localhost:5000/Memberships
[{"id":"83004bd8-9953-426f-a285-3eed395e9910","name":"курс","descriptions":"да","price":20},{"id":"5326b2b9-a65b-4360-a4d9-496284eb5a52","name":"Премиум","descriptions":"Безлимитный доступ во все зоны, включая бассейн и спа","price":5000}]
```

## Ссылка на Swager:

```
http://localhost:5000/swagger/index.html
```

