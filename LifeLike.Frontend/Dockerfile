FROM node:alpine as buildContainer

RUN npm install -g @angular/cli

WORKDIR /app
COPY . /app
RUN npm install
RUN ng build --prod

FROM nginx:alpine

ENV ENV=Dockerfile

COPY --from=buildContainer /app/nginx.conf /etc/nginx/nginx.conf
# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /usr/share/nginx/html
