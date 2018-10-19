FROM node:alpine as builder

RUN npm install -g @angular/cli

WORKDIR /app
COPY package*.json /app/
RUN npm install
COPY ./ /app/
ARG configuration=production
RUN npm run build -- --output-path=./dist/ --configuration 

FROM nginx:alpine
## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/*
## From 'builder' copy website to default nginx public folder
COPY --from=builder /app/dist /usr/share/nginx/html

EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]
