FROM node:alpine as buildContainer

RUN npm install -g @angular/cli

WORKDIR /app
COPY . /app
RUN npm install
RUN npm run build:ssr

FROM node:alpine

WORKDIR /app
# Copy dependency definitions
COPY --from=buildContainer /app/package.json /app
COPY --from=buildContainer /app/dist/server.js /app

# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /app/dist

# Expose the port the app runs in
EXPOSE 4200

# Serve the app
CMD ["npm", "run", "serve:ssr"]
    