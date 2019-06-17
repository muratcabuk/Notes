- offical url: https://sentry.io
- offical github url: https://github.com/getsentry/onpremise
- offical docker hub url: https://hub.docker.com/_/sentry/

- Configuration : https://docs.sentry.io/server/config/

- __install with compose__
- https://github.com/getsentry
- https://mikedombrowski.com/2018/03/self-hosting-sentry-with-docker-and-docker-compose/
- https://mikedombrowski.com/2018/03/self-hosting-sentry-with-docker-and-docker-compose/
- https://github.com/yhirano55/sentry-docker-compose/blob/master/docker-compose.yml
- https://medium.com/@prasincs/running-sentry-in-docker-compose-63b1c2683493
- https://gist.github.com/prasincs/b3bf25570b500a7c9b8b9241731ab7da#file-readme-md


- __Plugins__
- https://docs.sentry.io/server/plugins/
- https://gist.github.com/denji/b801f19d95b7d7910982c22bb1478f96







## __iki dosya düzenlendikten sonra alttaki komutlar vasıtasıyla docker container lar çalıştırılır.__

Compose klasöründeki iki dosya düzenlenir

- docker-compose.yml	
- sentry.env

- __Generate a random secret key and put it into the environment variable file__

docker-compose run --rm sentry-base sentry config generate-secret-key


- __Run database migrations (build the database)__

docker-compose run --rm sentry-base sentry upgrade --noinput


- __Startup the whole service__

docker-compose up -d



- __create a super user account__

docker-compose exec sentry-base sentry createuser --email YOUR_EMAIL --password YOUR_NEW_PASSWORD --superuser --no-input


- __If you want to chage someting in sentry docker just edit two files and run the following command__

 sudo docker-compose up --build -d







