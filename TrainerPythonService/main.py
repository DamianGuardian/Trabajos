from concurrent import futures
import grpc
from protos import trainerPython_pb2_grpc  # CAMBIO: usa el nombre correcto
from services.trainer_service import TrainerService

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainerPython_pb2_grpc.add_TrainerServiceServicer_to_server(
        TrainerService(), server
    )
    server.add_insecure_port('[::]:50051')  # Puerto correcto
    server.start()
    print("Server started on port 50051")
    server.wait_for_termination()

if __name__ == '__main__':
    try:
        serve()
    except Exception as e:
        import traceback
        print("¡Error al arrancar el servidor!", e)
        traceback.print_exc()
        raise
