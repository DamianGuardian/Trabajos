from pymongo import MongoClient
from bson import ObjectId
from models.trainer import Trainer

class TrainerRepository:
    def __init__(self):
        self.client = MongoClient("mongodb://localhost:27017/")
        self.db = self.client["trainerdb"]
        self.collection = self.db["trainers"]

    def create(self, trainer: Trainer):
        trainer_dict = trainer.to_dict()
        result = self.collection.insert_one(trainer_dict)
        trainer.id = str(result.inserted_id)
        return trainer

    def get_by_id(self, trainer_id: str):
        document = self.collection.find_one({"_id": ObjectId(trainer_id)})
        if document is None:
            return None

        return Trainer.from_dict(document)
