type OptionType = {
    value: string;
    name: string;
};

type MySelectProps = {
    options: OptionType[];
    defaultValue: string;
    value: string;
    onChange: (value: string) => void;
};

const MySelect: React.FC<MySelectProps> = ({
    options,
    defaultValue,
    value,
    onChange
}) => {
    return (
        <select
            value={value}
            onChange={(event) => onChange(event.target.value)}
        >
            <option disabled value="">
                {defaultValue}
            </option>

            {options.map((option) => (
                <option key={option.value} value={option.value}>
                    {option.name}
                </option>
            ))}
        </select>
    );
};

export default MySelect;