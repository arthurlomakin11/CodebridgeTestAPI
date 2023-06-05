# Тестовое API для Codebridge

## Установка



```
curl -fsSL https://get.docker.com -o get-docker.sh

sh get-docker.sh

sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose

sudo chmod +x /usr/local/bin/docker-compose

git clone https://github.com/arthurlomakin11/CodebridgeTestAPI.git

cd CodebridgeTestAPI

sudo docker compose up -d
```

API будет доступно по порту 5024

Можно подключится к MSSQL: порт 5000

Доступен SwaggerUI по endpoint /swagger

Username = sa

Password = xsf73.,23

## Инстанс на AWS
[API](http://13.49.32.36:5024/ping) развернуто на Ubuntu.

Также, можно подключится к БД по 13.49.32.36,5000

Есть [SwaggerUI](http://13.49.32.36:5024/swagger)

## Тесты
Репозиторий с [тестами API](https://github.com/arthurlomakin11/CodebridgeTestAPI.Tests).