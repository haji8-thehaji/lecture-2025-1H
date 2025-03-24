// MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;    // 현재 계산 값
        private string _currentOperator = ""; // 현재 연산자
        private bool _isNewEntry = true;     // 새 입력 여부

        public MainWindow()
        {
            InitializeComponent(); // XAML UI 초기화
        }

        // 숫자 버튼 클릭: 표시창에 숫자 입력
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (_isNewEntry)
            {
                Display.Text = button.Content.ToString(); // 새 숫자 시작
                _isNewEntry = false;
            }
            else
            {
                Display.Text += button.Content.ToString(); // 기존 숫자에 추가
            }
        }

        // 연산자 버튼 클릭: 연산 준비
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (double.TryParse(Display.Text, out double newValue))
            {
                if (!_isNewEntry)
                {
                    Calculate(newValue); // 이전 계산 수행
                }
                _currentOperator = button.Content.ToString(); // 연산자 저장
                if (_currentOperator == "%")
                {
                    // %는 현재 값을 기준으로 백분율 계산 후 즉시 적용
                    double percentageValue = _currentValue * (newValue / 100);
                    Calculate(percentageValue);
                    _currentOperator = ""; // % 계산 후 연산자 초기화
                }
                else
                {
                    _currentValue = newValue; // 일반 연산자는 값 저장
                }
                _isNewEntry = true; // 새 숫자 입력 대기
            }
        }

        // 등호 클릭: 계산 완료
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double newValue))
            {
                Calculate(newValue); // 최종 계산
                _currentOperator = ""; // 연산자 초기화
                _isNewEntry = true; // 새 입력 대기
            }
        }

        // 계산 로직: 사칙연산 처리
        private void Calculate(double newValue)
        {
            switch (_currentOperator)
            {
                case "+": _currentValue += newValue; break; // 덧셈
                case "-": _currentValue -= newValue; break; // 뺄셈
                case "×": _currentValue *= newValue; break; // 곱셈
                case "÷":
                    if (newValue != 0) _currentValue /= newValue; // 나눗셈
                    else MessageBox.Show("0으로 나눌 수 없습니다.", "오류");
                    break;
                // %는 Operator_Click에서 즉시 처리하므로 여기선 제외
            }
            Display.Text = _currentValue.ToString(); // 결과 표시
        }

        // 지우기 버튼: 초기화
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = 0; // 값 초기화
            _currentOperator = ""; // 연산자 초기화
            Display.Text = "0"; // 표시창 초기화
            _isNewEntry = true; // 새 입력 대기
        }
    }
}
