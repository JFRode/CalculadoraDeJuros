# CalculadoraDeJuros

### Endpoints
- /showMeTheCode
- /CalculadoraDeJuros/100&5
- /swagger

### Repositórios
- https://github.com/JFRode/Taxas
- https://github.com/JFRode/SDK

### Collection do Postman
Para facilitar o teste da aplicação, importe o arquivo da collection do Postman. Para isso abra o [Postman](https://www.postman.com) e siga as instruções abaixo:
- No menu File clique em Import;
- Na aba **File** clique em **Upload files**;
- Selecione o arquivo [Calculadora de Juros.postman_collection.json](https://github.com/JFRode/CalculadoraDeJuros/blob/master/Calculadora%20de%20Juros.postman_collection.json).

### Docker
Na pasta raiz do projeto, mesma que se encontra o arquivo .yml, execute:
- Para criar as imagens: ```docker build -t calculadoradejuros:1.0 .```
- Para iniciar o docker compose: ```docker-compose up -d```

#### DockerHub
- https://hub.docker.com/repository/docker/joaofelipegoncalves/taxas
- https://hub.docker.com/repository/docker/joaofelipegoncalves/calculadoradejuros
