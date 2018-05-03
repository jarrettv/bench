docker run --name bench-db -p 3306:3306 -e MYSQL_ALLOW_EMPTY_PASSWORD=yes -e MYSQL_DATABASE=db -e MYSQL_USER=dbuser -e MYSQL_PASSWORD=dbpass -d mysql --default-authentication-plugin=mysql_native_password

