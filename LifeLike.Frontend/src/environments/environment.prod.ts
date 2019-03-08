export const environment = {
  production: true,
  ENV: process.env != undefined ? process.env.ENV : "ENV File",
  API: process.env != undefined ?  process.env.API : "http:\\localhost",
};
