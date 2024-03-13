import cl from './MyButton.module.css'

type MyButtonProps = {
    children?: React.ReactNode;
} & React.ButtonHTMLAttributes<HTMLButtonElement>;

const MyButton: React.FC<MyButtonProps> = ({ children, ...props }) => {
    return (
        <button {...props} className={cl.myBtn}>
            {children}
        </button>
    );
};

export default MyButton;