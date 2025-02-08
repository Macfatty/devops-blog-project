# Use the official Nginx image as the base
FROM	nginx:latest



# Copy the static HTML files into the cointainer
COPY	../src/html /usr/share/nginx/html



# Expose port 80 for web trafic 
EXPOSE	80


# Start the Nginx web server
CMD	["nginx", "-g", "daemon off;"] 
