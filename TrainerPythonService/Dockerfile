FROM python:3.11-slim

# 🟢 Esto asegura que los logs se impriman inmediatamente
ENV PYTHONUNBUFFERED=1

# 🟢 Directorio de trabajo dentro del contenedor
WORKDIR /app

# 🟢 Instala dependencias
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# 🟢 Copia el resto del código
COPY . .

# 🟢 Expone el puerto gRPC
EXPOSE 50051

# 🟢 Ejecuta el servidor gRPC
CMD ["python", "-u", "main.py"]
