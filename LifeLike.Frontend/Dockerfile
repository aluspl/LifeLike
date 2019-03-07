FROM node:alpine as buildContainer

RUN npm install -g @angular/cli

WORKDIR /app
COPY . /app
RUN npm install
RUN ng build --prod

FROM nginx:alpine

WORKDIR /app
# Copy dependency definitions
COPY nginx.conf /etc/nginx/nginx.conf

# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /usr/share/nginx/html
    