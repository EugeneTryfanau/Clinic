ARG NODE_VERSION=20.11.1

FROM node:20.11.1-alpine
USER root

WORKDIR /app
COPY ["client/clinic-react-client/package*.json", "client/clinic-react-client/"]
WORKDIR /app/client/clinic-react-client
COPY . .
RUN npm install esbuild@0.19.10
RUN npm install

EXPOSE 5173
CMD [ "npm", "run", "dev" ]
