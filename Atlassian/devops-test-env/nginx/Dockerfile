FROM nginx:1.19.6-alpine



# RUN rm /etc/nginx/nginx.conf /etc/nginx/conf.d/default.conf
COPY cert/cert.pem /etc/ssl/certs/cert.pem
COPY cert/cert.key /etc/ssl/private/cert.key
COPY index.html /usr/share/nginx/html/index.html
#COPY default.conf /etc/nginx/conf.d/default.conf
COPY default.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443

CMD ["nginx", "-g", "daemon off;"]
