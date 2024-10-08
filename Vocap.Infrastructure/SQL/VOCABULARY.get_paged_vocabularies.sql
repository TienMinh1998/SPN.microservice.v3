-- create new pading vocap

CREATE OR REPLACE FUNCTION vocap.get_paged_vocabularies(page_number INT, page_size INT)
RETURNS TABLE(DaftWord TEXT, CamVocabulary_Audio TEXT, CamVocabulary_WordType TEXT, total_count bigint,CreatedUtcDate timestamp with time zone) 
AS
$$
BEGIN
    RETURN QUERY
    SELECT v."DaftWord", v."CamVocabulary_Audio", v."CamVocabulary_WordType",
           (SELECT COUNT(1) FROM vocap.vocabularies) AS total_count,
		   v."CreatedUtcDate"
    FROM vocap.vocabularies v
    ORDER BY v."DaftWord"
    OFFSET (page_number - 1) * page_size
    LIMIT page_size;
END;
$$ LANGUAGE plpgsql;