ARG NODE_VERSION=20.11.1

FROM node:22-alpine3.18
WORKDIR /app/client/clinic-react-client

COPY /client/clinic-react-client/package*.json .
RUN npm install

COPY . .
#RUN npm run build
EXPOSE 8080
EXPOSE 8081
CMD [ "npm", "run", "build" ]