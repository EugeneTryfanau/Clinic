import React, { ForwardedRef } from 'react'
import cl from './MyInput.module.css'

type MyInputProps = React.InputHTMLAttributes<HTMLInputElement>;

const MyInput = React.forwardRef<HTMLInputElement, MyInputProps>(
    (props, ref: ForwardedRef<HTMLInputElement>) => {
        return <input ref={ref} className={cl.myInput} {...props} />;
    }
);

export default MyInput;