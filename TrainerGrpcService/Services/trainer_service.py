from concurrent import futures
import grpc
import uuid
from google.protobuf.timestamp_pb2 import Timestamp
import datetime

import trainer_pb2
import trainer_pb2_grpc

class TrainerService(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        now = datetime.datetime.utcnow()
        birthdate = Timestamp()
        birthdate.FromDatetime(now)

        created_at = Timestamp()
        created_at.FromDatetime(now)

        return trainer_pb2.TrainerResponse(
            id=str(uuid.uuid4()),
            name="Pascual",
            age=99,
            birthdate=birthdate,
            createdAt=created_at,
            medals=[
                trainer_pb2.Medals(region="MX", type=trainer_pb2.MedalsType.Gold),
                trainer_pb2.Medals(region="JP", type=trainer_pb2.MedalsType.Silver)
            ]
        )

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("TrainerService gRPC server running on port 50051...")
    server.wait_for_termination()

if __name__ == "__main__":
    serve()
