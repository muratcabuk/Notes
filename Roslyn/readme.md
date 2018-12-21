# Starting, Stopping, and Reloading Configuration
### beginner guide
http://nginx.org/en/docs/beginners_guide.html


```
nginx -s signal

```
Where signal may be one of the following:

stop — fast shutdown
quit — graceful shutdown
reload — reloading the configuration file
reopen — reopening the log files


# Serving Static Content
```
server {
    location / {
        root /data/www;
    }

    location /images/ {
        root /data;
    }
}
```


# Reverse Proxy

### Load Balancing vs Reverse Proxy
https://www.nginx.com/resources/glossary/reverse-proxy-vs-load-balancer/

### resources

https://www.keycdn.com/support/nginx-reverse-proxy/

https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/

https://www.linode.com/docs/web-servers/nginx/use-nginx-reverse-proxy/

https://www.digitalocean.com/community/tutorials/how-to-configure-nginx-as-a-web-server-and-reverse-proxy-for-apache-on-one-ubuntu-14-04-droplet


This server will filter requests ending with .gif, .jpg, or .png and map them to the /data/images directory (by adding URI to the root directive’s parameter) and pass all other requests to the proxied server configured above.

```
server {
    location / {
        proxy_pass http://localhost:8080/;
    }

    location ~ \.(gif|jpg|png)$ {
        root /data/images;
    }
}
```





# Load Balancing

1. Go to /etc/nginx/sites-available
2. copy default file to <new-website-name>
3. configure new-website-name file with following lines
   
   ```
   upstream <anyname> {
   # local website addresses
   # we can also write a public ip or private ip addresses
   # we use the private ip addresses and port numbers
	server localhost:90;
	server localhost:100;	
	}

   server {
	listen 80;
	error_log  /usr/local/var/log/nginx/<domainname>.error.log error;
	error_log  /usr/local/var/log/nginx/<domainname>.notice.log  notice;
	error_log  /usr/local/var/log/nginx/<domainname>.info.log  info;

	server_name <domainname1> <domainname2> <*.domainname3>;
	
	index index.html index.htm index.nginx-debian.html;


	root /var/www/<domainname>;

	location / {
		proxy_pass	http://<anyname>;
		proxy_http_version 1.1;
		proxy_set_header	X-Real-IP $remote_addr;
		proxy_set_header	Upgrade $http_upgrade;
      proxy_set_header	Connection keep-alive;
      proxy_set_header	Host $host;
      proxy_set_header	X-Forwarded-For $proxy_add_x_forwarded_for;
      proxy_set_header	X-Forwarded-Proto $scheme;
		proxy_set_header	X-Forwarded-User  $remote_user;
      # if you use a routing in your website comment following line
		#try_files 	$uri $uri/ =404;
		}
	}
   ```
4. create a folder containing your website's files and folders in /var/www/<domainname>


```
add gzip
server {

   #...previous content
   
   gzip on;
   
   gzip_types application/javascript image/* text/css;
   
   gunzip on;
   
}
```

installed modules list
```
nginx -V 2>&1 | tr -- - '\n' | grep module
```


### resources

https://www.atlantic.net/cloud-hosting/how-to-install-configure-nginx-load-balancer-ubuntu/

https://spin.atomicobject.com/2012/02/28/load-balancing-and-reverse-proxying-with-nginx/

https://www.linode.com/docs/uptime/loadbalancing/use-nginx-as-a-front-end-proxy-and-software-load-balancer/

https://www.sep.com/sep-blog/2017/02/28/load-balancing-with-nginx-and-docker/

https://hackprogramming.com/how-to-setup-subdomain-or-host-multiple-domains-using-nginx-in-linux-server/

https://www.nginx.com/resources/glossary/reverse-proxy-vs-load-balancer/

# Setting Up FastCGI Proxying

nginx can be used to route requests to FastCGI servers which run applications built with various frameworks and programming languages such as PHP.

The most basic nginx configuration to work with a FastCGI server includes using the fastcgi_pass directive instead of the proxy_pass directive, and fastcgi_param directives to set parameters passed to a FastCGI server. 

```
server {
    location / {
        fastcgi_pass  localhost:9000;
        fastcgi_param SCRIPT_FILENAME $document_root$fastcgi_script_name;
        fastcgi_param QUERY_STRING    $query_string;
    }

    location ~ \.(gif|jpg|png)$ {
        root /data/images;
    }
}

```





