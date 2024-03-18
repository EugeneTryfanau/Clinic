interface StandartParams {
    limit?: number,
    page?: number
}

interface StandartParamsWithId extends StandartParams {
    id: string
}

interface StandartParamsWithEntity<T> extends StandartParams {
    entity: T
}

interface StandartParamsWithIdAndEntity<T> extends StandartParamsWithId {
    entity: T
}

interface StandartParamsWithEntityAndFunctions<T> extends StandartParamsWithEntity<T> {
    delete: Function,
    open: Function
}

interface VisibilityParams {
    visible: boolean,
    setVisibility: Function
}

interface CreateParams extends VisibilityParams {
    create: Function
}