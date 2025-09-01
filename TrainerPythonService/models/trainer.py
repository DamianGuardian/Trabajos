class Trainer:
    def __init__(self, id, name, age, birthdate, medals):
        self.id = id
        self.name = name
        self.age = age
        self.birthdate = birthdate
        self.medals = medals

    def to_dict(self):
        return {
            "name": self.name,
            "age": self.age,
            "birthdate": self.birthdate,  # puede ser datetime o dict
            "medals": [{"region": m.region, "type": m.type} for m in self.medals]
        }

    @staticmethod
    def from_dict(doc):
        return Trainer(
            id=str(doc["_id"]),
            name=doc["name"],
            age=doc["age"],
            birthdate=doc["birthdate"],
            medals=doc["medals"]
        )
