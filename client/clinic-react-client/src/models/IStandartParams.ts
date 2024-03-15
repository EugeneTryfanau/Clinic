interface StandartParams {
    limit?: number,
    page?: number
}

interface StandartParamsWithId extends StandartParams{
    id: string
}

interface StandartParamsWithEntity<T> extends StandartParams{
    entity: T
}

interface StandartParamsWithIdAndEntity<T> extends StandartParamsWithId{
    entity: T
}