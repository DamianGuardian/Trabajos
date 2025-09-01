import grpc
from google.protobuf.timestamp_pb2 import Timestamp
from datetime import datetime

from repositories.trainer_repository import TrainerRepository
from mappers.trainer_mapper import map_dto_to_entity
from dtos.create_trainer_request import CreateTrainerRequestDTO

from protos import trainerPython_pb2, trainerPython_pb2_grpc


class TrainerService(trainerPython_pb2_grpc.TrainerServiceServicer):
    def __init__(self):
        self.repo = TrainerRepository()

    def CreateTrainer(self, request, context):
        dto = CreateTrainerRequestDTO(
            name=request.name,
            age=request.age,
            birthdate=str(request.birthdate),
            medals=request.medals,
            id=request.id
        )
        trainer = self.repo.create(map_dto_to_entity(dto))

        created_at = Timestamp()
        created_at.GetCurrentTime()

        return trainerPython_pb2.TrainerResponse(
            id=trainer.id,
            name=trainer.name,
            age=trainer.age,
            birthdate=trainer.birthdate,
            medals=trainer.medals,
            created_at=created_at
        )

    def GetTrainer(self, request, context):
        trainer = self.repo.get_by_id(request.id)
        if trainer is None:
            context.abort(grpc.StatusCode.NOT_FOUND, "Trainer not found")

        created_at = Timestamp()
        created_at.GetCurrentTime()

        return trainerPython_pb2.TrainerResponse(
            id=trainer.id,
            name=trainer.name,
            age=trainer.age,
            birthdate=trainer.birthdate,
            medals=trainer.medals,
            created_at=created_at
        )
