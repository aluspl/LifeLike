export const environment = {
  production: true,
  ENV: process.env.ENV != undefined ? process.env.ENV : "ENV File",
  API: process.env.API != undefined ?  process.env.API : "http://localhost",
};
