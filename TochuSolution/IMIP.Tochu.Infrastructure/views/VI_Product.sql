IF NOT EXISTS (
    SELECT * 
    FROM sys.views 
    WHERE name = 'VI_PRODUCT'
)
BEGIN
    EXEC('
        CREATE VIEW VI_PRODUCT AS
        SELECT 
            A.UserHinban,
            A.UserHinmei,
            B.NOUSCD
        FROM T0000MS_Item_RCS A 
        LEFT JOIN SI_SEINOUMST B 
            ON B.PRODUCT = A.UserHinban
    ')
END