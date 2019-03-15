FROM node:alpine as buildContainer

RUN npm install -g @angular/cli

WORKDIR /app
COPY . /app
RUN npm install
RUN npm rebuild node-sass
RUN ng build --prod

FROM nginx:alpine

VOLUME  /var/cache/nginx

ENV ENV="Docker Image"
ENV API="http://localhost"
COPY --from=buildContainer /app/nginx.conf /etc/nginx/conf.d/default.conf
# Get all the code needed to run the app
COPY --from=buildContainer /app/dist/browser /usr/share/nginx/html
EXPOSE 80
