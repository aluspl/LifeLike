FROM node:alpine as buildContainer

RUN npm install -g @angular/cli

WORKDIR /app
COPY . /app
RUN npm install
RUN ng build --prod

FROM nginx:alpine

COPY nginx.conf /etc/nginx/nginx.conf

WORKDIR /app
# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /usr/share/nginx/html
