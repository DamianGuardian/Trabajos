from models.trainer import Trainer, Medal
from dtos.create_trainer_request import CreateTrainerRequestDTO

def map_dto_to_entity(dto: CreateTrainerRequestDTO) -> Trainer:
    medals = [Medal(m["region"], m["type"]) for m in dto.medals]
    return Trainer(id=None, name=dto.name, age=dto.age, birthdate=dto.birthdate, medals=medals)
