-- update time to learn every day 
-- if not exists  -> inserst 
-- of exists      -> update time, created log 

DROP FUNCTION if exists vocap.func_update_time_for_lestening;

CREATE OR REPLACE FUNCTION vocap.func_update_time_for_lestening(my_time INT)
RETURNS TABLE(Date Date,Id INT, TimeToListening INT, TypeListening TEXT) 
AS
$$
BEGIN
    SET timezone = 'Asia/Ho_Chi_Minh'; 
    IF EXISTS (SELECT * FROM vocap.listenings WHERE DATE("CreatedUtcDate")  = CURRENT_DATE ) THEN
        -- Nếu tồn tại, thực hiện UPDATE
       		UPDATE vocap.listenings 
			SET "TimeToListening" = "TimeToListening" + @my_time
			WHERE DATE("CreatedUtcDate")  = CURRENT_DATE;
    ELSE
        -- Nếu không tồn tại, thực hiện INSERT
        INSERT INTO vocap.listenings ("TimeToListening","TypeListening","CreatedUtcDate")
        VALUES (0,'WEB',CURRENT_TIMESTAMP);
    END IF;
	RETURN QUERY SELECT  DATE("CreatedUtcDate") as "Date", "Id","TimeToListening","TypeListening" 
	FROM vocap.listenings WHERE DATE("CreatedUtcDate") = CURRENT_DATE;
END;
$$ 
LANGUAGE plpgsql;

-- EXAMPLE : 
-- SELECT * FROM vocap.func_update_time_for_lestening(10)
-- SELECT * FROM vocap.listenings