CREATE TRIGGER copy_data1
AFTER INSERT ON Questions
WHEN new.type = 1
BEGIN
    INSERT INTO Flashcards (ID, CreatorID, Question)
    VALUES (new.ID, new.CreatorID, new.Question);
END;