# Stage 1: Build Angular app
FROM node:20 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build -- --configuration production

# Stage 2: Serve app with nginx
FROM nginx:1.25
COPY --from=build /app/dist/bug-tracker.ui /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]